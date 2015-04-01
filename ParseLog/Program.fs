// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open System
open Nessos.UnionArgParser

type CLIArguments =
    | [<Mandatory>] InputFile of string
    | OutputFile of string
with
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | InputFile _ -> "specify an input file"
            | OutputFile _ -> "specify an output file"

// build the argument parser
let parser = UnionArgParser.Create<CLIArguments>()

// get usage text
let usage = parser.Usage()
// output:
//    --inputfile <string>: specify an input file.
//    --outputfile <string>: specify an output file.
//    --help [-h|/h|/help|/?]: display this list of options.


[<EntryPoint>]
let main argv = 
    let result = parser.Parse(argv)
    let inputfile = result.GetResult <@ InputFile @>
    let outputfile = result.GetResult (<@ OutputFile @>, defaultValue = "")
    let res = Console.ReadLine()
    0 // return an integer exit code
