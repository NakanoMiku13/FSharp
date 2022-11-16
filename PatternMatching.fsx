open System.IO
module Float =
    let tryFromString s =
        if s = "N/A" then
            None
        else
            Some (float s)
    let fromStringOr v s =
        s |> tryFromString |> Option.defaultValue v
type Student =
    {
        Surname : string
        GivenName : string
        Id : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }
module Student =
    let namePart (s : string) =
        let elements = s.Split(',')
        let Surname = elements[0].Trim()
        let GivenName = elements[1].Trim()
        (Surname,GivenName)
    let namePart (s : string) =
    let fromString( s : string ) =
        let elements = s.Split('\t')
        let sur, given = elements[0] |> namePart
        let id = elements[1]
        let score = elements
                            |> Array.skip 2
                            |> Array.map (Float.fromStringOr 100.0)
        let meanScore2 = score |> Array.average
        let lowestScore = score |> Array.min
        let highestScore = score |> Array.max
        {
            Surname = sur
            GivenName = given
            Id = id
            MeanScore = meanScore2
            MinScore = lowestScore
            MaxScore = highestScore
        }
    let printSumary (student : Student) =
        printfn "%s\t%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Surname student.GivenName student.Id student.MeanScore student.MinScore student.MaxScore
let summarize filePath =
    let rows = File.ReadAllLines filePath
    let studenCount = (rows |> Array.length) - 1
    printfn "Student count: %d" studenCount
    rows
    |> Array.skip 1
    |> Array.map Student.fromString
    |> Array.sortBy (fun student -> student.Surname)
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