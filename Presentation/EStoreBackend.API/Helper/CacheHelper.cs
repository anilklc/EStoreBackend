using Microsoft.AspNetCore.OutputCaching;

namespace EStoreBackend.API.Helper
{
    public  class CacheHelper
    {
        private readonly IOutputCacheStore _outputCacheStore;

        public CacheHelper(IOutputCacheStore outputCacheStore)
        {
            _outputCacheStore = outputCacheStore;
        }

        public Task EvictByTagAsync(string tag)
        {
            return _outputCacheStore.EvictByTagAsync(tag, CancellationToken.None).AsTask();
        }
    }
}
