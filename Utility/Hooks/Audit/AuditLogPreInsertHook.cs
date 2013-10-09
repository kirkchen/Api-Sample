using EFHooks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApiSample.Utility.Hooks.Audit
{
    public class AuditLogPreInsertHook : PreInsertHook<IIdentifiable>
    {
        public HttpContextBase HttpContext { get; set; }

        public AuditLogPreInsertHook(HttpContextBase httpContext)
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
           
            //// Get entity type and associate etadata
            var entityType = entity.GetType();
            TypeDescriptor.AddProvider(new AssociatedMetadataTypeTypeDescriptionProvider(entityType), entityType);

            //// Get is entity contains requireAudit Field, and add auditlog
            var properties = TypeDescriptor.GetProperties(entityType);
            foreach (PropertyDescriptor propertyDescriptor in properties)
            {
                //// If contains requireAudit attribute, add audit log
                var propRequireAudit = propertyDescriptor.Attributes.OfType<RequireAuditAttribute>().FirstOrDefault();
                if (propRequireAudit == null)
                {
                    continue;
                }

                AuditLog auditLog = new AuditLog();
                auditLog.IdentifyKey = entity.IdentifyKey;
                auditLog.IdentifyName = entityType.Name;
                auditLog.OriginValue = string.Empty;
                auditLog.NewValue = propertyDescriptor.GetValue(entity).ToString();
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
