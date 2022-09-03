let ls = [1..999]
let rec multiples l =
    match l with
    | head :: tail ->
        if(head % 3 = 0 || head % 5 = 0) then
            head + multiples tail
        else
            multiples tail
    | [] -> 0
let t = multiples ls
printfn "%d" t