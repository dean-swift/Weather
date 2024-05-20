@ModelType List(Of WeatherApp.DataAccess.UserLocation)
@Code
    ViewData("Title") = "Index"
End Code



<div class="container overflow-hidden">
    <!--Page header-->
    <section class="row" aria-labelledby="locationsTitle">
        <h2 id="locationsTitle">Locations</h2>
        <p class="lead">Use this page to manage your saved locations.</p>

        <div class="row">

            <!--File upload section-->
            <section class="row" aria-labelledby="uploadFileTitle">
                <h3 id="uploadFileTitle">Upload Locations</h3>
                <p>Browse for and upload a CSV file containing a list of locations in the following format to receive a forcast for each of them:</p>
                <ul>
                    <li> Latitude,</li>
                    <li> Longitude,</li>
                    <li> Location Name</li>
                </ul>
                <form action="~/UserLocation/UploadFile" method="post" enctype="multipart/form-data">
                    <div class="input-group">
                        <input type="file" class="form-control" id="inputFileSelect" aria-describedby="uploadFileButton" aria-label="Upload" name="file">
                        <Button class="btn btn-dark" type="submit" id="uploadFileButton">Upload</Button>
                    </div>
                </form>

                <!--Display any errors-->
                @If Not IsNothing(ViewBag.Error) Then
                    @<section class="row">
                        <p class="text-danger">@ViewBag.Error</p>
                    </section>
                End If
                <!--Display any other messages-->
                @If Not IsNothing(ViewBag.Message) Then
                    @<section class="row">
                        <p class="text-info">@ViewBag.Message</p>
                    </section>
                End If
            </section>
        </div>

        <!--Display of stored location data using model-->
        <div class="row gy-3">
            <section class="row" aria-labelledby="savedLocationsTitle">
                <h3 id="savedLocationsTitle">Saved Locations</h3>

                <!--Output of stored data using model-->
                @If Model IsNot Nothing AndAlso Model.Count > 0 Then

                    @<p>Click on a location name for an extended forcast</p>

                    @<div Class="table-responsive">

                        <table class="table table-sm table-striped">
                            <thead class="table-dark">
                                <tr>
                                    <th scope="col">Location ID</th>
                                    <th scope="col">Location Name</th>
                                    <th scope="col">Latitude</th>
                                    <th scope="col">Longitude</th>
                                    <th scope="col">Forcast Date</th>
                                    <th scope="col">Min Temperature today</th>
                                    <th scope="col">Max Temperature today</th>
                                    <th scope="col"></th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <!--Loop through locations-->
                                @For Each userLocation In Model
                                    @<tr>
                                        <td>@userLocation.UserLocationId</td>
                                        <td>@userLocation.LocationName</td>
                                        <td>@userLocation.Latitude</td>
                                        <td>@userLocation.Longitude</td>
                                        @If userLocation.WeatherForcasts.Count > 0 AndAlso userLocation.WeatherForcasts(0).WeatherForcastItems IsNot Nothing Then
                                            @<td>@userLocation.WeatherForcasts(userLocation.WeatherForcasts.Count - 1).ForcastDate</td>
                                            @<td>@Math.Round(userLocation.WeatherForcasts(userLocation.WeatherForcasts.Count - 1).WeatherForcastItems(0).TemperatureMin.Value, 1)</td>
                                            @<td>@Math.Round(userLocation.WeatherForcasts(userLocation.WeatherForcasts.Count - 1).WeatherForcastItems(0).TemperatureMax.Value, 1)</td>
                                        Else
                                            @<td colspan="3" class="text-center text-info">Click the Weather button to get a forcast</td>
                                        End If

                                        <td>@Html.ActionLink("Weather", "Index", "WeatherForcast", New With {.id = userLocation.UserLocationId}, New With {.class = "btn btn-outline-dark"})</td>
                                        <td>@Html.ActionLink("Delete", "Delete", New With {.id = userLocation.UserLocationId}, New With {.class = "btn btn-outline-dark"})</td>
                                    </tr>
                                Next
                            </tbody>
                        </table>
                    </div>
                Else
                    @<P><em>No locations have been uploaded</em></P>
                End If

            </section>

        </div>
    </section>
</div>

