@ModelType WeatherApp.DataAccess.UserLocation

@Code
    ViewData("Title") = "Weather Forcast"
    Dim forcastCount As Integer
    If Model IsNot Nothing Then
        forcastCount = Model.WeatherForcasts.Count
    End If
End Code


<main>
    <!--Page header-->
    <section class="row" aria-labelledby="aspnetTitle">
        <h1 id="aspnetTitle">7 Day weather forcast</h1>
        <p class="lead">This is the 7 day weather forcast for the requested location</p>
    </section>

    <!--Display any errors-->
    @If Not IsNothing(ViewBag.Error) Then
        @<section Class="row">
            <p Class="text-danger">@ViewBag.Error</p>
        </section>
    End If

    <!--Output of stored data using model-->
    @If Model IsNot Nothing Then

        @<div Class="row">
            <section Class="col-md-4" aria-labelledby="locationDetailsTitle">
                <h2 id="locationDetailsTitle"> Location Details</h2>
                <p> These are the details For this location</p>
                <Table Class="table table-sm table-striped">
                    <tr>
                        <td> Name :</td>
                        <td>@Model.LocationName</td>
                    </tr>
                    <tr>
                        <td> Location Id :</td>
                        <td>@Model.UserLocationId</td>
                    </tr>
                    <tr>
                        <td> Latitude :</td>
                        <td>@Model.Latitude</td>
                    </tr>
                    <tr>
                        <td> Longitude :</td>
                        <td>@Model.Longitude</td>
                    </tr>
                </Table>
            </section>

            <section Class="col-md-8" aria-labelledby="locationsTitle">
                <h2 id="locationsTitle"> Latest weather forcast</h2>

                @If Model.WeatherForcasts.Count > 0 AndAlso Model.WeatherForcasts(0).WeatherForcastItems IsNot Nothing Then
                    @<p> This forcast has ID @Model.WeatherForcasts(forcastCount - 1).WeatherForcastId And was generated in @Model.WeatherForcasts(forcastCount - 1).GenerationtimeMs ms on @Model.WeatherForcasts(forcastCount - 1).ForcastDate</p>

                    @<div Class="table-responsive">
                        <Table Class="table table-sm table-striped">
                            <thead Class="table-dark">
                                <tr>
                                    <th scope = "col" > Forcast Date</th>
                                    @For Each forcastItem In Model.WeatherForcasts(forcastCount - 1).WeatherForcastItems
                                        @<th scope="col">@Format(forcastItem.WeatherItemDate, "dd-MMM-yy")</th>
                                    Next
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td> Weather Code</td>
                                    @For Each forcastItem In Model.WeatherForcasts(forcastCount - 1).WeatherForcastItems
                                        @<td>@Math.Floor(forcastItem.WeatherCode.Value)</td>
                                    Next
                                </tr>
                                <tr>
                                    <td> Max Temperature °C</td>
                                    @For Each forcastItem In Model.WeatherForcasts(forcastCount - 1).WeatherForcastItems
                                        @<td>@Math.Round(forcastItem.TemperatureMax.Value, 1)</td>
                                    Next
                                </tr>
                                <tr>
                                    <td> Min Temperature °C</td>
                                    @For Each forcastItem In Model.WeatherForcasts(forcastCount - 1).WeatherForcastItems
                                        @<td>@Math.Round(forcastItem.TemperatureMin.Value, 1)</td>
                                    Next
                                </tr>
                            </tbody>
                        </Table>
                    </div>
                Else
                    @<p>No forcasts yet for this location, refresh below</p>
                End If

                <!--Display update button-->
                @Html.ActionLink("Refresh forcast", "UpdateWeather", New With {.locationId = Model.UserLocationId}, New With {.class = "btn btn-outline-dark"})
            </section>

        </div>
    End If

    <!--Display back button-->
    @Html.ActionLink("Back to list", "Index", "UserLocation", Nothing, New With {.class = "btn btn-outline-dark"})
</main>


