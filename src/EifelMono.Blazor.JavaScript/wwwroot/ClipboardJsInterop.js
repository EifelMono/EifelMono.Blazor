window.EifelMonoBlazorJavaScriptClipboardJsInterop = {
    WriteText: async (text) => {
        if (navigator.clipboard) {
            try {
                document.querySelector('p').Sele
                await navigator.clipboard.writeText(text);
                return true;
            }
            catch (err) {
                console.error(err);
            }
        }
        return false;
    }
};


