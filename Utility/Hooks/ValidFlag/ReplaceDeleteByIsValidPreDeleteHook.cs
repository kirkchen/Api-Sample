using EFHooks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Utility.Hooks.ValidFlag
{
    public class ReplaceDeleteByIsValidPreDeleteHook : PreDeleteHook<IIsValid>
    {
        public override void Hook(IIsValid entity, HookEntityMetadata metadata)
        {
            entity.IsValid = false;

            metadata.CurrentContext.Entry(entity).State = EntityState.Modified;
        }

        public override bool RequiresValidation
        {
            get { return false; }
        }
    }
}
