namespace Sum
module Summaries =
    open System.IO
    open Students
    let summarize filePath =
        let rows = File.ReadAllLines filePath
        let studenCount = (rows |> Array.length) - 1
        printfn "Student count: %d" studenCount
        rows
        |> Array.skip 1
        |> Array.map Student.fromString
        //Here we use a lambda expresion to shortcut the process, instead of using a function
        |> Array.sortBy (fun student -> student.Surname)
        //|> Array.sortByDescending (fun student -> student.MeanScore)
        |> Array.iter Student.printSumary