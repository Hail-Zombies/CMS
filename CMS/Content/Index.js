﻿function Home_Load() {
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
        $("#carousel_tabs").carousel('cycle');
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
    var item = $("#carousel_news>div.carousel-inner");
    if (data.length > 1) {
        item.append(`
                <div class="item active">
                    <img src="`+ data[0].Img + `" alt="...">
                    <div class="carousel-caption"></div>
                    <a href="/Article?id=`+ data[0].Id + `" target="_blank">` + data[0].Title + `</a>
                </div>`);
        for (var i = 1; i < data.length; i++) {
            item.append(`
                <div class="item">
                    <img src="`+ data[i % 2].Img + `" alt="...">
                    <div class="carousel-caption"></div>
                    <a href="/Article?id=`+ data[i].Id + `"  target="_blank">` + data[i].Title + `</a>
                </div>`
            );
        }
    }
    $("#carousel_news img").each(function () {
        var ratio = 0.5625;  // 缩放比例
        var width = $("#carousel_news .carousel-inner").width();    // 图片实际宽度
        var height = width * ratio;    // 计算等比例缩放后的高度
        $(this).css("height", height);  // 设定等比例缩放后的高度
    })
}

function parseDate(update_time) {
    var list = update_time.split("T");
    var date = list[0].split("-");
    return `[` + date[1] + `-` + date[2] + `]`;
}
function Create_news(rootdiv, data) {
    for (var i = 0; i < data.length; i++) {
        rootdiv.append(`
        <li>
            <a href="/Article?id=`+ data[i].Id + `">` + data[i].Title + `</a>
            <p>`+ parseDate(data[i].Update_time) + `</p>
        </li>`);
    }
}