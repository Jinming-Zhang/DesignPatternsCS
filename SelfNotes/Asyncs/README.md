# Asynchronous Functions

## **async** modifier

An async method runs synchronously until it reaches its first await expression, at which point the method is suspended until the awaited task is complete. In the meantime, control returns to the caller of the method, as the example in the next section shows.

```cs
public async Task<int> ExampleMethodAsync()
{
    //...
}
```

The await operator suspends evaluation of the enclosing async method (the async method that uses await) until the asynchronous operation represented by its operand completes. When the asynchronous operation completes, the await operator returns the result of the operation, if any.

The await operator doesn't block the thread that evaluates the async method (the thread which calls the async method). When the await operator suspends the enclosing async method, the control returns to the caller of the method.

```cs
public void Caller()
{
    SomeAsyncFunctionCall();
    SomeotherCode();
}

public async Task<int> SomeAsyncFunctionCall(){
    DoSomething();
    await TookSomeTime(1000);
    return 666;
}
```

The _Caller()_ function will continue to _SomeotherCode_ when the **await** operator gives back _Caller_ the control while it's finishing the _TookSomeTime_ job.

However, the _Caller()_ function will not look back and get the result of the async function again, unless change the _Caller()_ to an async function and use **await** to wait for the result.

## Task asynchronous programming model (TAP)

To utilize async programming, we can use the **Task** class provided. It can store and manage the async process and provide return type of each async task.

Example of a Task returns a customized class that perform http requests:

```cs
public static async Task<AsyncHTTPRequest> GetFakeRequestAsync(int timeToSpend)
        {
            AsyncHTTPRequest fakeRequest = new AsyncHTTPRequest("fakeurl");
            await Task.Delay(timeToSpend * 1000);
            fakeRequest.result = "Finally finished the fake task";
            return fakeRequest;
        }
```

Note if we want wait for the result of the Task get finished, we have to make a async function to await the tasks.

We will start the async function by calling the async function, store it in a Task variable can let us check its states and do more managements.

```cs
public static async Task Demo()
        {
            // with async programming
            // this starts task 1
            Task<AsyncHTTPRequest> reqAsync1 = AsyncHTTPRequest.GetFakeRequestAsync(1);
            // this starts task 2
            Task<AsyncHTTPRequest> reqAsync2 = AsyncHTTPRequest.GetFakeRequestAsync(2);
            // this starts task 3
            Task<AsyncHTTPRequest> reqAsync3 = AsyncHTTPRequest.GetFakeRequestAsync(3);
            // await for individual task to complete
            await reqAsync2;
            // or wait for a list of tasks to complete
            Task.WaitAll(reqAsync1, reqAsync2, reqAsync3);
        }
```
