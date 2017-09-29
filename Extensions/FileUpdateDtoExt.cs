using System;
using System.Collections.Generic;
using System.Linq;
using LawPanel.ApiClient.Exceptions;
using LawPanel.ApiClient.Models.FilesAndFolders;
using LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates;

namespace LawPanel.ApiClient.Extensions
{

    public class FileUpdateDtoExtension
    {
        private readonly List<FileTemplateComponentDto> _templateComponents;
        private readonly List<FileComponentDto> _componentsOriginal;
        private readonly FileUpdateDto _fileUpdate;

        public FileUpdateDtoExtension(FileUpdateDto fileUpdate, List<FileTemplateComponentDto> templateComponents, List<FileComponentDto> componentsOriginal)
        {
            _templateComponents = templateComponents;
            _componentsOriginal = componentsOriginal;
            _fileUpdate = fileUpdate;
        }

        public FileUpdateDtoExtension Set(string name, string value, string entityId = null)
        {
            // Validations
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name of component is required", nameof(name));
            if (_fileUpdate.Components == null) _fileUpdate.Components = new List<FileComponentCreateUpdateDto>();

            // Get component
            var fileTemplateComponentDto = _templateComponents.FirstOrDefault(c => c.Name == name);
            if (fileTemplateComponentDto == null) throw new LawPanelException($"There is no component with name {name}");


            // Component exist?
            var component = _fileUpdate.Components.FirstOrDefault(m => m.FileTemplateComponentId.ToLowerInvariant() == fileTemplateComponentDto.Id.ToLowerInvariant());
            if (component == null)
            {
                component = new FileComponentCreateUpdateDto
                {
                    FileTemplateComponentId = fileTemplateComponentDto.Id,
                    EntityId = entityId,
                    Value = value
                };
            }
            else
            {
                _fileUpdate.Components.Remove(component);

                component.EntityId = entityId;
                component.FileTemplateComponentId = fileTemplateComponentDto.Id;
                component.Value = value;
            }

            // Updating saved values?
            if (_componentsOriginal != null && _componentsOriginal.Any())
            {
                var componentOriginal = _componentsOriginal.FirstOrDefault(c => c.Id.ToLowerInvariant() == fileTemplateComponentDto.Id.ToLowerInvariant());
                if (componentOriginal != null)
                {
                    component.Id = componentOriginal.Id;
                }
            }
            
            _fileUpdate.Components.Add(component);

            return this;
        }

    }

    public static class FileUpdateDtoExt
    {
        public static FileUpdateDtoExtension Using(this FileUpdateDto fileUpdate, FileDto file)
        {
            return new FileUpdateDtoExtension(fileUpdate, file.FileTemplate.FileTemplateComponents, file.Components);
        }
    }
}