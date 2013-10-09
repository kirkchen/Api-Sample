using EFHooks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApiSample.Utility.Hooks.Audit
{
    public class AuditLogPreUpdateHook : PreUpdateHook<IIdentifiable>
    {
        public HttpContextBase HttpContext { get; set; }

        public AuditLogPreUpdateHook(HttpContextBase httpContext)
        {
            this.HttpContext = httpContext;
        }

        public override void Hook(IIdentifiable entity, HookEntityMetadata metadata)
        {
            //// Check is auditable context, contains auditlog table
            IAuditableContext context = metadata.CurrentContext as IAuditableContext;
            if (context == null)
            {
                return;
            }

            //// Get current username
            var userName = "Unlogin";
            if (this.HttpContext != null)
            {
                userName = this.HttpContext.User.Identity.Name;
            }
            
            //// Get entry, entity type and associate etadata
            var entry = ((IObjectContextAdapter)metadata.CurrentContext).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
            var entityType = entity.GetType();
            TypeDescriptor.AddProvider(new AssociatedMetadataTypeTypeDescriptionProvider(entityType), entityType);

            //// Get is entity modified property contains requireAudit Field, and add auditlog
            var properties = TypeDescriptor.GetProperties(entityType);
            foreach (string propertyName in entry.GetModifiedProperties())
            {
                //// Check is property need io
                var propertyDescriptor = properties.Find(propertyName, true);
                var propRequireAudit = propertyDescriptor.Attributes.OfType<RequireAuditAttribute>().FirstOrDefault();
                if (propRequireAudit == null)
                {
                    continue;
                }

                //// Get original value
                DbDataRecord original = entry.OriginalValues;
                string oldValue = original.GetValue(original.GetOrdinal(propertyName)).ToString();

                //// Get new value
                CurrentValueRecord current = entry.CurrentValues;
                string newValue = current.GetValue(current.GetOrdinal(propertyName)).ToString();

                //// Write Audit Log
                AuditLog auditLog = new AuditLog();
                auditLog.IdentifyKey = entity.IdentifyKey;
                auditLog.IdentifyName = entityType.Name;
                auditLog.OriginValue = oldValue;
                auditLog.NewValue = newValue;
                auditLog.CreatedAt = DateTime.Now;
                auditLog.CreatedBy = userName;

                context.AuditLogs.Add(auditLog);
            }
        }

        public override bool RequiresValidation
        {
            get { return false; }
        }
    }
}
