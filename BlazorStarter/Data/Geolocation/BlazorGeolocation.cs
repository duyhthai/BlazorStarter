using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorStarter.Data.Geolocation
{
	public class BlazorGeolocation
	{
		private readonly IJSRuntime js;
		private Action<Position> OnGetPosition;
		private Action<PositionError> OnGetPositionError;

		public BlazorGeolocation(IJSRuntime js)
		{
			this.js = js;
		}

		public async ValueTask<bool> HasGeolocationFeature() =>
			await js.InvokeAsync<bool>("blazorGeolocation.hasGeolocationFeature");

		[JSInvokable]
		public void RaiseOnGetPosition(Position p) =>
			OnGetPosition?.Invoke(p);

		[JSInvokable]
		public void RaiseOnGetPositionError(PositionError err) =>
			OnGetPositionError?.Invoke(err);

		public async ValueTask GetCurrentPosition(
			Action<Position> onSuccess,
			Action<PositionError> onError,
			PositionOptions options = null)
		{
			OnGetPosition = onSuccess;
			OnGetPositionError = onError;
			await js.InvokeVoidAsync(
				"blazorGeolocation.getCurrentPosition",
				DotNetObjectReference.Create(this),
				options);
		}
	}
}
