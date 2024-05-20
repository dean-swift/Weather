@Code
    ViewData("Title") = "About"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewData("Title").</h2>
    <h3>@ViewData("Message")</h3>

    <p>This application is a demo that uses the <a href="https://open-meteo.com/">Open-Meteo</a> service to display weather forcasts for provided location lists.</p>
</main>