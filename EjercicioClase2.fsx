let limite = 1000
let numeros = [1..limite]
let potencia (a,b) : int =
    let mutable res = 1
    for i in 1..b do
        res <- res * a
    res
let sumatoria a = (a * (a + 1)) / 2
let cuadradosDeNumeros(b) : int  =
    let mutable res = 0
    for i in b do
        res <- res + potencia(i,2)
    res
let resultado =  potencia(sumatoria(limite),2) - cuadradosDeNumeros(numeros)
printfn "Ejercicio 1: %d" resultado

printfn "Ingresa el texto:\n"
let isograma = System.Console.ReadLine()
let mutable inputMap:Map<char,int> = Map.empty
let mutable check = false
for i in isograma do
    if (inputMap.ContainsKey(i)) then
        check <- true
    else
        inputMap <- inputMap.Add(i,1)
printfn "El texto %s" isograma
if(check) then printfn "No es un isograma\n"
else printfn "Es un isograma\n"