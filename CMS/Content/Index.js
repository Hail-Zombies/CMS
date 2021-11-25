function Home_Load() {
    var data = {
        labels: ["一月", "二月", "三月", "四月", "五月", "六月", "七月"],
        datasets: [{
            label: "蓝队",
            color: 'blue',
            data: [65, 59, 80, 81, 56, 55, 40]
        }, {
            label: "绿队",
            color: 'green',
            data: [28, 48, 40, 19, 86, 27, 90]
        }]
    };

    var options = {
        responsive: true
    }; // 图表配置项，可以留空来使用默认的配置
    var myBarChart = $('#myBarChart').barChart(data, options);

    var id = 1;
    $(function () {
        $("#carousel_tabs").carousel('pause');
        $("#nav_tabs>li").hover(
            function () {
                $(".slide-" + String(id)).removeClass("active");
                id = Number($(this).attr("class").split("-")[1]);
                //console.log(id);
                $("#carousel_tabs").carousel(id - 1);
                $(this).addClass("active");
                $("#carousel_tabs").carousel('pause');
            },
            function () {
                $("#carousel_tabs").carousel('cycle');
            }
        );
        // 获取轮播索引
        $('#carousel_tabs').on('slide.zui.carousel', function (event) {
            var $hoder = $('#carousel_tabs').find('.item'),
                $items = $(event.relatedTarget);
            //getIndex就是轮播到当前位置的索引
            var getIndex = $hoder.index($items);
            $(".slide-" + String(id)).removeClass("active");
            id = getIndex + 1;
            $(".slide-" + String(id)).addClass("active");
        });
    });
}

function Creat_carousel_news(data) {
    var rootdiv = $("#carousel_news");
    var ol, item, a;
    if (data.length > 1) {
        ol = $(`
            <ol class="carousel-indicators">
            </ol>`);
        ol.append(`<li data-target="#carousel_news" data-slide-to="0" class="active"></li>`);
        item = $(`
            <div class="carousel-inner">
            </div>`);
        item.append(`
                <div class="item active">
                    <img src="`+ data[0].Img + `" alt="...">
                    <div class="carousel-caption"></div>
                    <a href="/Article?id=`+ data[0].Id + `">` + data[0].Title + `</a>
                </div>
                <div class="item">
                    <img src="`+ data[1].Img + `" alt="...">
                    <div class="carousel-caption"></div>
                    <a href="/Article?id=`+ data[1].Id + `">` + data[1].Title + `</a>
                </div>
                <div class="item">
                    <img src="`+ data[0].Img + `" alt="...">
                    <div class="carousel-caption"></div>
                    <a href="/Article?id=`+ data[2].Id + `">` + data[2].Title + `</a>
                </div>
                <div class="item">
                    <img src="`+ data[1].Img + `" alt="...">
                    <div class="carousel-caption"></div>
                    <a href="/Article?id=`+ data[3].Id + `">` + data[3].Title + `</a>
                </div>
            </div>`);
        a = $(`
            <a class="left carousel-control" href="#carousel_news" role="button" data-slide="prev">
                <span class="icon icon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#carousel_news" role="button" data-slide="next">
                <span class="icon icon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>`);
        for (var i = 1; i < data.length; i++) {
            ol.append(`<li data-target="#carousel_news" data-slide-to="` + i + `"></li>`);
            item.append(`
                <div class="item">
                    <img src="`+ data[i % 2].Img + `" alt="...">
                    <div class="carousel-caption"></div>
                    <a href="/Article?id=`+ data[i].Id + `">` + data[i].Title + `</a>
                </div>`
            );
        }
    }

    rootdiv.append(ol, item, a);

    $("#carousel_news img").each(function () {
        var ratio = 0.5625;  // 缩放比例
        var width = $("#carousel_news .carousel-inner").width();    // 图片实际宽度
        var height = width * ratio;    // 计算等比例缩放后的高度
        $(this).css("height", height);  // 设定等比例缩放后的高度
    })

    var js = $(`
    <link href="/zui/css/zui.css" rel="stylesheet"/>
<script src="/Scripts/jquery-3.6.0.js"></script>
    <script src="/zui/js/zui.min.js"></script>`);
    $("#carousel_news").append(js);
}