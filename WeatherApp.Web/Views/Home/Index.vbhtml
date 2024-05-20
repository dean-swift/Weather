@Code
    ViewData("Title") = "Home Page"
End Code

<main>
    <!--Page header-->
    <section class="row" aria-labelledby="aspnetTitle">
        <h1 id="aspnetTitle">Your Weather Forcast</h1>
        <p class="lead">This is a tool to get a weather forcast for a set of locations.</p>
        <p class="lead">Go to the @Html.ActionLink("Locations", "Index", "UserLocation") page to get started.</p>
    </section>

    <!--Display any errors-->
    @If Not IsNothing(ViewBag.Error) Then
        @<section Class="row">
            <p Class="text-danger">@ViewBag.Error</p>
        </section>
    End If

</main>
