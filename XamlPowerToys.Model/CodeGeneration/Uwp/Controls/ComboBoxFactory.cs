﻿namespace XamlPowerToys.Model.CodeGeneration.Uwp.Controls {
    using System;
    using System.Text;
    using XamlPowerToys.Model.CodeGeneration.Infrastructure;
    using XamlPowerToys.Model.Infrastructure;
    using XamlPowerToys.Model.Uwp;

    public class ComboBoxFactory : IControlFactory {

        readonly ControlTemplateModel<ComboBoxEditorProperties> _model;

        public ComboBoxFactory(GenerateFormModel generateFormModel, PropertyInformationViewModel propertyInformationViewModel) {
            if (generateFormModel == null) {
                throw new ArgumentNullException(nameof(generateFormModel));
            }
            if (propertyInformationViewModel == null) {
                throw new ArgumentNullException(nameof(propertyInformationViewModel));
            }
            _model = new ControlTemplateModel<ComboBoxEditorProperties>(generateFormModel, propertyInformationViewModel);
        }

        public string MakeControl(Int32? parentGridColumn = null, Int32? parentGridRow = null) {
            var sb = new StringBuilder("<ComboBox ");

            if (parentGridColumn != null) {
                sb.Append($"Grid.Column=\"{parentGridColumn.Value}\" ");
            }
            if (parentGridRow != null) {
                sb.Append($"Grid.Row=\"{parentGridRow.Value}\" ");
            }

            sb.Append(_model.EditorProperties.DisplayMemberPathText);
            sb.Append(_model.EditorProperties.SelectedItemPathText);
            sb.Append(_model.EditorProperties.SelectedValuePathText);
            sb.Append(_model.EditorProperties.ItemsSourceText);
            
            if (!String.IsNullOrWhiteSpace(_model.BindingPath)) {
                sb.AppendFormat("{0}=\"{1}\" ", _model.EditorProperties.EditorBindingTargetProperty, Helpers.ConstructBinding(_model.BindingPath, _model.BindingMode, _model.StringFormatText, _model.BindingConverter));
            }

            sb.Append(_model.WidthText);
            sb.Append(_model.HeightText);
            sb.Append(_model.HorizontalAlignmentText);
            sb.Append(_model.VerticalAlignmentText);
            sb.Append(_model.ControlNameText);
            sb.Append("/>");
            return sb.ToString().CompactString();
        }

    }
}
