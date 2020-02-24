window.EifelMonoBlazorMonacoEditorJsInterop = window.EifelMonoBlazorMonacoEditorJsInterop || {};
window.EifelMonoBlazorMonacoEditorJsInterop.Editors = [];

window.EifelMonoBlazorMonacoEditorJsInterop.Editor = {
    InitializeEditor: function (model) {
        let thisEditor = monaco.editor.create(document.getElementById(model.id), model.options);
        if (window.EifelMonoBlazorMonacoEditorJsInterop.Editors.find(e => e.id === model.id)) {
            return false;
        }
        else {
            window.EifelMonoBlazorMonacoEditorJsInterop.Editors.push({ id: model.id, editor: thisEditor });
        }
        return true;
    },
    GetValue: function (id) {
        let myEditor = window.EifelMonoBlazorMonacoEditorJsInterop.Editors.find(e => e.id === id);
        if (!myEditor) {
            throw `Could not find a editor with id: '${window.EifelMonoBlazorMonacoEditorJsInterop.Editors.length}' '${id}'`;
        }
        return myEditor.editor.getValue();
    },
    SetValue: function (id, value) {
        let myEditor = window.EifelMonoBlazorMonacoEditorJsInterop.Editors.find(e => e.id === id);
        if (!myEditor) {
            throw `Could not find a editor with id: '${window.EifelMonoBlazorMonacoEditorJsInterop.Editors.length}' '${id}'`;
        }
        myEditor.editor.setValue(value);
        return true;
    },
    SetTheme: function (id, theme) {
        let myEditor = window.EifelMonoBlazorMonacoEditorJsInterop.Editors.find(e => e.id === id);
        if (!myEditor) {
            throw `Could not find a editor with id: '${window.EifelMonoBlazorMonacoEditorJsInterop.Editors.length}' '${id}'`;
        }
        monaco.editor.setTheme(theme);
        return true;
    }
};
