open System.IO
let printMeanScore (row : string) =
    //Here we clear the white spaces into the text
    let elements = row.Split(' ')
    let name = elements[0]
    let id = elements[1]
    let score = elements |> Array.skip 2 |> Array.map float
    //let meanScore =
        //Here we convert the elements from string to float, with a simple map, next we get the average of all
    //    elements |> Array.skip 2 |> Array.map float |> Array.average
    //With this one we can simplify the first one, we can get the same result
    //Because, it makes the convertion automatic, and we just worry about to skip the first two elements
    let meanScore2 = score |> Array.average
    let lowestScore = score |> Array.min
    let highestScore = score |> Array.max
                //With %0.1f we specify how many numbers we want after the zero
    printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" name id meanScore2 lowestScore highestScore
let summarize filePath =
    //Reading all the rows of the file
    let rows = File.ReadAllLines filePath
    let studenCount = (rows |> Array.length) - 1
    printfn "Student count: %d" studenCount
    rows |> Array.skip 1 |> Array.iter printMeanScore
[<EntryPoint>]
let main argv =
    //Collection is something that can hold series of elements, each begin and the end are the same type
    //Collection function is a function that in the arguments it recieve collections as elements
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