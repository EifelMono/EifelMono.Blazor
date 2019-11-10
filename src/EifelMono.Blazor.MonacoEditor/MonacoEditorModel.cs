﻿using EifelMono.Blazor.MonacoEditor.Options;
using System;

namespace EifelMono.Blazor.MonacoEditor
{
    public class MonacoEditorModel
    {
        public MonacoEditorModel() { }

        public MonacoEditorModel(EditorOptions options)
        {
            Options = options;
        }

        public string Id { get; set; } = $"EifelMonoMonacoEditor_{Guid.NewGuid()}";
        public EditorOptions Options { get; set; } = new EditorOptions();
    }
}
