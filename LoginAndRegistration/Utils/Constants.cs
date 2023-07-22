using EasyForm.Enum;

namespace EasyForm.Utils
{
    public static class Constants
    {
        public const string CreateAction = "Create";
        public const string IndexAction = "Index";
        public const string EditAction = "Edit";
        public const string UserError = "Something went wrong";
        public const string IsShow = "IsShow";


        public const string NormalUser = nameof(UserRole.NormalUser);
        public const string Admin = nameof(UserRole.Admin);

        public const string SpinnerPagUrl = "~/Views/Shared/Spinner.cshtml";
        public const int PageItems = 10;

    }
}
