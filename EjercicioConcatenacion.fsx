printfn "Type the number of elements for the first list\n"
let n = int(System.Console.ReadLine())
let ls1 = [for i in 1..n -> i]
printfn "Type the number of elements for the first list\n"
let m = int(System.Console.ReadLine())
let ls2 = [for i in 1..m -> i+n]
let concatList a b = a @ b
let t = concatList ls1 ls2 
printfn "%A" t