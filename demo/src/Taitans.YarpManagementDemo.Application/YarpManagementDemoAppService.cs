using System;
using System.Collections.Generic;
using System.Text;
using Taitans.YarpManagementDemo.Localization;
using Volo.Abp.Application.Services;

namespace Taitans.YarpManagementDemo;

/* Inherit your application services from this class.
 */
public abstract class YarpManagementDemoAppService : ApplicationService
{
    protected YarpManagementDemoAppService()
    {
        LocalizationResource = typeof(YarpManagementDemoResource);
    }
}
