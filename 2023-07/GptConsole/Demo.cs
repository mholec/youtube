//
// await foreach (string item in GetData())
// {
//     Console.WriteLine(item);
// }
//
//
//
//
//
// async IAsyncEnumerable<string> GetData()
// {
//     for(int i=1; i<=10; i++)
//     {
//         var text = await GetRow(i);
//         yield return text;
//     }
// }
//
// async Task<string> GetRow(int i)
// {
//     await Task.Delay(500);
//     return await Task.FromResult($"řádek číslo {i}");
// }