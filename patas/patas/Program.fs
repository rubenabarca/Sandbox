let nthroot n A =
    let rec f x =
        let m = n - 1.
        let x' = (m * x + A/x**m) / n
        match abs(x' - x) with
        | t when t < abs(x * 1e-9) -> x'
        | _ -> f x'
    f (A / double n)

let geometricMean n = 
    let seriesProduct = List.fold (*) 1.0 [1.0..n]
    let seriesCount = float(Seq.length [1.0..n])
    nthroot seriesCount seriesProduct

let rec agm a g precision  =
    if precision > abs(a - g) then a else
    agm (0.5 * (a + g)) (sqrt (a * g)) precision

open System

[<EntryPoint>]
let main args =
    if args.Length <> 2 then
        eprintfn "usage: nthroot n A"
        exit 1
    let (b, n) = System.Double.TryParse(args.[0])
    let (b', A) = System.Double.TryParse(args.[1])
    if (not b) || (not b') then
        eprintfn "error: parameter must be a number"
        exit 1
    printf "%A" (nthroot n A)
    Console.ReadLine() |> ignore
    0