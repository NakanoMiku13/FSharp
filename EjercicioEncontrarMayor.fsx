printfn "Type the numbers that you want to insert into the list\n"
let n = int(System.Console.ReadLine())
open System.Collections.Generic
let dict = new Dictionary<int,int>()
for i in 1..n do
    dict.Add(i,int(System.Console.ReadLine()))
let list = List.sort [for i in dict.Values -> i]
let maxNumber = list.Item(list.Length-1)
printfn "The max number is: %d" maxNumber