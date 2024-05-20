@Code
    ViewData("Title") = "Contact"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewData("Title").</h2>
    <h3>@ViewData("Message")</h3>

    <address>
        Dean Swift<br />
        Chelmsford<br />
        Essex<br />
        UK
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:swift.dean@gmail.com">swift.dean@gmail.com</a>
    </address>
</main>