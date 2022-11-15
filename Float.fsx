//When we use the namespace in modules we define the name that we want to use in other files
//We need to be careful when we order the files, 'cause if we set one above or bellow the main program
//maybe we can not use the functions from the file
namespace FloatFunctions
module Float =
    let tryFromString s =
        if s = "N/A" then
            //When we use none we indicate that it did not exist data from that input
            None
        else
            //In this case we have to specify that our function can return a none value, and a float value
            //That it is indicated with the prefix convertion Some, that say "It can exist some values"
            Some (float s)
    let fromStringOr v s =
        s |> tryFromString |> Option.defaultValue v
