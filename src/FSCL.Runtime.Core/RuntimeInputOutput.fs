namespace FSCL.Runtime

open System
open FSCL.Compiler
open System.Collections.Generic
open OpenCL
open System.Reflection
open Microsoft.FSharp.Quotations
open FSCL.Language

type OpenCLKernelCreationResult(callArgs: Expr list,
                                deviceData: RuntimeDevice,
                                kernelData: RuntimeKernel,
                                runtimeKernelData: RuntimeCompiledKernel) =

    member val CallArgs = callArgs with get
    member val DeviceData = deviceData with get
    member val KernelData = kernelData with get
    member val CompiledKernelData = runtimeKernelData with get
    
type MultithreadKernelCreationResult(callArgs: Expr list,
                                     kernelData: IKernelInfo) =

    member val CallArgs = callArgs with get
    member val KernelData = kernelData with get
    
type ComputationCreationResult =
| OpenCLKernel of OpenCLKernelCreationResult
| MultithreadKernel of MultithreadKernelCreationResult
| RegularFunction of (Expr option * MethodInfo * Expr list)

type ExecutionOutput =     
    | ReturnedTrackedBuffer of OpenCLBuffer * Array
    | ReturnedUntrackedBuffer of OpenCLBuffer
    | ReturnedValue of obj


    