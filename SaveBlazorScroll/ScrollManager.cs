using Microsoft.JSInterop;

namespace SaveBlazorScroll
{


    public class ScrollManager : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public ScrollManager(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/SaveBlazorScroll/blazorScroll.js").AsTask());
        }

        public async Task SaveScrollPosition()
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("SaveScrollPosition");
        }

        public async Task RestoreScrollPosition()
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("RestoreScrollPosition");
        }


        public async Task SaveScrollPosition(string key)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("SaveScrollPositionKey",key);
        }

        public async Task RestoreScrollPosition(string key)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("RestoreScrollPositionKey",key);
        }

        public async Task DeleteScrollPosition(string key)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("DeleteScrollPositionKey", key);
        }


        public async Task DeleteScrollPosition()
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("DeleteScrollPosition");
        }



        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}