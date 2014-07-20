<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPi.Gadgets.NewRelic.Models.NewRelicGadgetModel>" %>
<%@ Import Namespace="EPi.Gadgets.NewRelic.Business" %>


<div class="epi-contentArea epi-padding">
    <h3><%= Model.ServerSummary.ServerName %></h3>
</div>
<div id="visualizer-<%= Html.GetGadgetId() %>" class="epi-contentArea epi-paddingHorizontal"></div>
<div id="data-<%= Html.GetGadgetId() %>" class="epi-contentArea epi-paddingHorizontal" data-memory="<%= Model.ServerSummary.Memory %>" data-cpu="<%= Model.ServerSummary.Cpu %>" data-disc="<%= Model.ServerSummary.FullestDisk %>">
    <table>
       <tbody>
            <tr>
                <td style="width: 33%;">Memory: <%= Model.ServerSummary.Memory %>%</td>
                <td style="width: 33%;">CPU: <%= Model.ServerSummary.Cpu %>%</td>
                <td style="width: 33%;">Fullest Disc: <%= Model.ServerSummary.FullestDisk %>%</td>
            </tr>
            <tr>
                <td style="width: 33%;">Memory Total: <%= Helpers.FormatBytes(this.Model.ServerSummary.MemoryTotal) %></td>
                <td style="width: 33%;">CPU Stolen: <%= Model.ServerSummary.CpuStolen %></td>
                <td style="width: 33%;">Fullest Disc Free: <%= Helpers.FormatBytes(this.Model.ServerSummary.FullestDiskFree) %></td>
            </tr>
            <tr>
                <td style="width: 33%;">Memory Used: <%= Helpers.FormatBytes(this.Model.ServerSummary.MemoryUsed) %></td>
                <td style="width: 33%;"></td>
                <td style="width: 33%;">Disc IO: <%= Model.ServerSummary.DiskIo %><br />
                </td>
            </tr>
        </tbody>
    </table>
</div>

<script type="text/javascript">
    function drawChart() {
        var visualizer = document.getElementById('visualizer-<%= Html.GetGadgetId() %>');
        var data = google.visualization.arrayToDataTable([
          ['Label', 'Value'],
          ['Memory', <%= Model.ServerSummary.Memory %>],
          ['CPU', <%= Model.ServerSummary.Cpu %>],
          ['Disc', <%= Model.ServerSummary.FullestDisk %>]
        ]);

        var gaugeOptions = {
            min: 0, max: 100, yellowFrom: 70, yellowTo: 85,
            redFrom: 85, redTo: 100, minorTicks: 5, backgroundColor: 'transparent', 'title': 'Server info', 'width': 600, 'height': 300
        };

        // Create and draw the visualization.
        new google.visualization.Gauge(visualizer).draw(data, gaugeOptions);
    }
</script>