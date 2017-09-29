using System;
using System.Collections.Generic;
using System.Linq;
using LawPanel.ApiClient.Models.FilesAndFolders;

namespace LawPanel.ApiClient.Extensions
{
    public static class FileDtoExt
    {
        public static FileUpdateDto ToFileUpdateDto(this FileDto file)
        {
            var fileUpdate = new FileUpdateDto
            {
                Id = file.Id,
                Name = file.Name,
                FileStatusId = file.FileStatus.Id.ToGuid(),
                Number = file.Number,
                Tags = file.Tags?.Select(t=>t.Id.ToGuid()).ToList() ?? new List<Guid>(),
                UserId = file.User.Id.ToGuid(),
                Components = new List<FileComponentCreateUpdateDto>()
            };
            

            foreach (var fileComponentDto in file.Components)
            {
                fileUpdate.Components.Add(new FileComponentCreateUpdateDto
                {
                    Id = fileComponentDto.Id,
                    EntityId = fileComponentDto.EntityId,
                    FileTemplateComponentId = fileComponentDto.FileTemplateComponent.Id,
                    Value = fileComponentDto.Value,
                    ValueBlobId = fileComponentDto.ValueBlobId,
                    CreatedAt = fileComponentDto.CreatedAt,
                    Enable = fileComponentDto.Enable
                });
            }

            return fileUpdate;
        }
    }
}
