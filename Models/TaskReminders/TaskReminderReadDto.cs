using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.FilesAndFolders;
using LawPanel.ApiClient.Models.Flatteneds;

namespace LawPanel.ApiClient.Models.TaskReminders
{
    public class TaskReminderReadDto : Dto, IIdentifiableDto
    {
        public string                               Id                  { get; set; }
        public string                               Name                { get; set; }
        public DateTime                             DateTime            { get; set; }
        public TaskReminderReadTaskDto              Task                { get; set; }
        public TaskReminderReadFileDto              File                { get; set; }
        public TaskReminderReadUserDto              User                { get; set; }
        public bool                                 IsSeen              { get; set; }
        public bool                                 IsLastTaskReminder  { get; set; }
        public string                               Notes               { get; set; }
        public bool?                                IsDeadLine          { get; set; }
        public IEnumerable<TaskReminderReadUserDto> KeepInformed        { get; set; }

        public TaskReminderReadDto()
        {
            KeepInformed = new List<TaskReminderReadUserDto>();
        }

    }

    #region Flattened DTOs

    #region TaskDto

    public class TaskReminderReadTaskDto 
    {
        public Guid     Id          { get; set; }
        public string   Name        { get; set; }
        public DateTime DateTimeDue { get; set; }
    }

    #endregion

    #region FileDto
    public class TaskReminderReadFileDto : FlattenedDto<FileDto>
    {
        public Guid                                             Id                  { get; set; }
        public string                                           Name                { get; set; }
        public string                                           Number              { get; set; }
        public TaskReminderReadClientDto                        Client              { get; set; } // Agent
        public TaskReminderReadUserDto                          Owner               { get; set; }
        public IEnumerable<TaskReminderReadFilePortfolioDto>    FilePortfolios      { get; set; }
        public TaskReminderReadFileTemplateDto                  FileTemplate        { get; set; }
        public IEnumerable<TaskReminderReadUserDto>             OtherSupervisors    { get; set; }
    }
    #endregion

    #region FirmPortfolioDto
    public class TaskReminderReadFirmPortfolioDto 
    {
        public Guid                         Id                  { get; set; }
        public string                       ApplicationNumber   { get; set; }
        public string                       MarkText            { get; set; }
        public TaskReminderReadRegistryDto  Registry            { get; set; }
        public string                       MarkOwner           { get; set; }
        public string                       ImageUrl            { get; set; }
    }
    #endregion

    #region FilePortfolioDto
    public class TaskReminderReadFilePortfolioDto 
    {
        public Guid                                 Id                  { get; set; }
        public TaskReminderReadFirmPortfolioDto     FirmPortfolio       { get; set; }
        public TaskReminderReadFilePortfolioRoleDto FilePortfolioRole   { get; set; }
    }
    #endregion

    #region FilePortfolioRoleDto
    public class TaskReminderReadFilePortfolioRoleDto
    {
        public Guid     Id    { get; set; }
        public string   Name  { get; set; }
        public bool     IsOwn { get; set; }
    }
    #endregion

    #region ClientDto
    public class TaskReminderReadClientDto : FlattenedDto<ClientDto>
    {
        public Guid     Id    { get; set; }
        public string   Name  { get; set; }
    }
    #endregion

    #region FileTemplateDto
    public class TaskReminderReadFileTemplateDto 
    {
        public Guid     Id    { get; set; }
        public string   Name  { get; set; }
    }
    #endregion

    #region UserDto
    public class TaskReminderReadUserDto 
    {
        public Guid     Id          { get; set; }
        public string   FirstName   { get; set; }
        public string   LastName    { get; set; }
    }
    #endregion

    #region RegistryDto
    public class TaskReminderReadRegistryDto 
    {
        public Guid     Id                      { get; set; }
        public string   Name                    { get; set; }
        public string   Description             { get; set; }
        public string   OfficialName            { get; set; }
        public string   WipoCode                { get; set; }
        public string   UrlBaseForTrademarks    { get; set; }
        public int      TrademarkRegistry       { get; set; }
    }
    #endregion

    #endregion
}