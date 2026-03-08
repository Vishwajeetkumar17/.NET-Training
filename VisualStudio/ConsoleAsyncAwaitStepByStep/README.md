# C# Async/Await — Step-by-step Console Samples (ZIP)

This project contains small console samples to learn `async` and `await` one step at a time.

## Requirements
- .NET SDK 8.0+ installed

## Run (CLI)
From this folder:
```bash
dotnet build
dotnet run
```

## How to use
- Run the app.
- Choose sample number (1 to 6).
- Read the console output and then return to the menu.

## Samples included
1) `await Task.Delay` — basic async wait + timestamps  
2) `Task<T>` — return a value from an async method  
3) Async method chain — one async method awaits another  
4) `Task.WhenAll` — start tasks first, then await all together  
5) Exceptions — try/catch with await  
6) Cancellation — cancel a running async loop using `CancellationToken`

Tip: Read the comments inside each `SampleXX_*.cs` file.
