namespace Students
open FloatFunctions
open StudentScores
type Student =
    {
        Surname : string
        GivenName : string
        Id : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }
//let fromStringOr50 s =
//    s |> Option.defaultValue 50.0
//After that we can create a module, that is basically where we can create functions to the type data or record types
module Student =
    let namePart (s : string) =
        let elements = s.Split(',')
        match elements with
        | [|surname;givenName|] ->
            {| Surname = surname.Trim()
               GivenName = givenName.Trim() |}
        | [|surname|] ->
            {|  Surname = surname.Trim()
                GivenName = "(None)"|}
        | _ -> raise(System.FormatException(sprintf "Invalid name format"))
    let checkScore(a : float[]) =
        match a with
        | data -> {|Mean = Array.average data; Lowest = Array.min data; Highest = Array.max data|}
        | _ -> raise(sprintf(""))
    let fromString( s : string ) =
        let elements = s.Split('\t')
        let name = elements[0] |> namePart
        let id = elements[1]
        //If we try to use the convertion with map, we have the problem that we are using option(float), and not float at all
        //So, when we try to make the average, it throws an error 'cause we can operate + on option(float)
        //But when we use .choose option, we say that the compiler ignore the values that says None, and create the full
        //Convertion, so if we have [1,2,3,None,4] after applying the .choose function we will have [1,2,3,4]
        let score = elements
                            |> Array.skip 2
                            |> Array.map TestResult.fromString
                            |> Array.choose TestResult.tryEffectiveScore
        let meanScore2 = score |> Array.average
        let lowestScore = score |> Array.min
        let highestScore = score |> Array.max
        {
            Surname = name.Surname
            GivenName = name.GivenName
            Id = id
            MeanScore = meanScore2
            MinScore = lowestScore
            MaxScore = highestScore
        }
    let printSumary (student : Student) =
        printfn "%s\t%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Surname student.GivenName student.Id student.MeanScore student.MinScore student.MaxScore
