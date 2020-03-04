namespace LawPanel.ApiClient.Enums.Permissions
{
    // Do not change numbers, just add news
    public enum Claims
    {
        UserChangeAccountDataForOthersUsers = 0,
        

        PortfolioReadOnly = 100,
        PortfolioInternalLimitedUser = 101,
        PortfolioExternalLimitedUser = 102,

        #region Client area 
        ClientAreaReadOnly = 10000,
        ClientAreaManageCasesNotes = 10001,
        ClientAreaManageCasesAttachmentFiles = 10002,
        ClientAreaManageCasesAttachmentLinks = 10003,
        #endregion
    }
}
