open System.IO
open StudentScores
//Here we adding a extra module to the Float datatype
//When we use type data, we can say that we are using classes or structs, like in C or C++
//were we create data types and names
type Student =
    {
        Name : string
        Id : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }
//let fromStringOr50 s =
//    s |> Option.defaultValue 50.0
//After that we can create a module, that is basically where we can create functions to the type data or record types
module Student =
    let fromString( s : string ) =
        let elements = s.Split('\t')
        let name = elements[0]
        let id = elements[1]
        //If we try to use the convertion with map, we have the problem that we are using option(float), and not float at all
        //So, when we try to make the average, it throws an error 'cause we can operate + on option(float)
        //But when we use .choose option, we say that the compiler ignore the values that says None, and create the full
        //Convertion, so if we have [1,2,3,None,4] after applying the .choose function we will have [1,2,3,4]
        let score = elements
                            |> Array.skip 2
                            |> Array.map (Float.fromStringOr 100.0)
        let meanScore2 = score |> Array.average
        let lowestScore = score |> Array.min
        let highestScore = score |> Array.max
        {
            Name = name
            Id = id
            MeanScore = meanScore2
            MinScore = lowestScore
            MaxScore = highestScore
        }
    let printSumary (student : Student) =
        printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Name student.Id student.MeanScore student.MinScore student.MaxScore
let summarize filePath =
    let rows = File.ReadAllLines filePath
    let studenCount = (rows |> Array.length) - 1
    printfn "Student count: %d" studenCount
    rows
    |> Array.skip 1
    |> Array.map Student.fromString
    //Here we use a lambda expresion to shortcut the process, instead of using a function
    |> Array.sortBy (fun student -> student.Name)
    //|> Array.sortByDescending (fun student -> student.MeanScore)
    |> Array.iter Student.printSumary
[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let filePath = argv[0]
        printfn "Processing %s" filePath
        if File.Exists(filePath) then
            summarize filePath
            0
        else
            printfn "There is no file"
            2
    else
        printfn "Error, please try again"
        1