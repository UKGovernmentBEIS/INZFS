using INZFS.MVC.Models.Core;
using INZFS.MVC.ViewModels;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace INZFS.MVC.Drivers.Core
{

    public class RefrenceNumberDriver : BaseDriver<RefrenceNumberPart, RefrenceNumberViewModel>
    {
        public override async Task<IDisplayResult> UpdateAsync(RefrenceNumberPart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var viewModel = new RefrenceNumberViewModel();

            await updater.TryUpdateModelAsync(viewModel, Prefix);

            part.FundAbbvreviation = viewModel.FundAbbvreviation;
            part.FundRound = viewModel.FundRound;
            part.AutomatedNumber = viewModel.AutomatedNumber;


            return await EditAsync(part, context);
        }

        protected override void PopulateViewModel(RefrenceNumberPart part, RefrenceNumberViewModel viewModel)
        {
            viewModel.RefrenceNumberPart = part;

            viewModel.FundAbbvreviation = part.FundAbbvreviation;
            viewModel.FundRound = part.FundRound;
            viewModel.AutomatedNumber = part.AutomatedNumber;

        }
    }
}
