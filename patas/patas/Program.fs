open System


let nthPiDigit k = 
    (1./(16.**k)) * (4./(8.*k+1.) - 2./(8.*k+4.) - 1./(8.*k+5.) - 1./(8.*k+6.));;

let modularExponentiation b e m = (b**e)%m

[<EntryPoint>]
let main args =
    let precision = 1.
    let piDigitList = List.map nthPiDigit [1.0 .. precision]
    let piResult = List.reduce (+) piDigitList
    Console.WriteLine(piResult)
    Console.ReadLine() |> ignore
    0