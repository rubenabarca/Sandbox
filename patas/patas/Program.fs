open System

[<EntryPoint>]
let main args =
    let mutable a = (1.+1./sqrt(2.))/2.
    let mutable c = 1./(8.*a)
    let mutable s = a**2.
    let mutable  f = 1.
    let precision = 0.00000000001
    let mutable absC = abs(c)
    while absC < precision do
        a <- (a+sqrt((a-c)*(a+c)))/2.
        c <- (c**2.) / (4.*a)
        f <- 2.*f
        s <- s-f*c**2.
        absC <- abs(c)
        
    Console.ReadLine() |> ignore
    0