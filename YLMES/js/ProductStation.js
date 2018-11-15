$(function () {


   
    layui.use(['table', 'layer', 'form'], function () {

        var table = layui.table, layer = layui.layer
        , form = layui.form;
        $("#Search").click(function () {
            var NameSearch = $("#Name").val().trim();
        
            table.render({
                elem: '#tw'
                , url: '/SystemSettings/SeProductStation?Name=' + NameSearch
                , page: true
                ,height: 'full-20'
                , limit: 15
                , cols: [[
                      { field: '7', hide: true }
                    , { field: '序号', width: 50, title: '序号' }
                    , { field: '工位', width: 235, title: '工位', edit: Text }
                    , { field: '工位类型编号', width: 210, title: '工位类型编号' }
                    , { field: '工位类型', width: 235, title: '工位类型', edit: Text }
                    , {
                        fieid: '线别', width: 210, title: '线别', templet: "#aaad"
                    }
                    , { width: 178, align: 'center', toolbar: '#barDemo' }
                ]]

            });
        
        });
        $('tr td:nth-child(6) div').on('change',function () {
            alert();
        })
        
        table.on('tool(demo)', function (obj) { //注：tool 是工具条事件名，test 是 table 原始容器的属性 lay-filter="对应的值"
            var data = obj.data //获得当前行数据
                , layEvent = obj.event; //获得 lay-event 对应的值  
            var Station = null;
            var StationType = null;
            var id = null;
            var Line = null;
            if (data.线别 != null) {
                Line =data.线别
            }
            if (data.工位 != null) {
                Station = data.工位
            }
            if (data.工位类型 != null) { 
                StationType = data.工位类型
            } if (data.序号 != null) {
                id = data.序号
            }
            if (layEvent === 'detail') {
       
                layer.msg(Line)
            } else if (layEvent === 'del') {
                layer.confirm('真的删除行么', function (index) {
                    $.ajax({
                        url: "/SystemSettings/DlProductStation",
                        data: { StationID: id },
                        type: "post",
                        dataType: "text",
                        success: function (data) {
                            if (data == "true") {
                                layer.msg('删除成功');
                            }
                        }
                    });
                    obj.del(); //删除对应行（tr）的DOM结构
                    layer.close(index);
                    //向服务端发送删除指令
                });
            } else if (layEvent === 'edit') {               
                $.ajax({
                    url: "/SystemSettings/UpProductStation",
                    data: { line: Line, StationID: id, Station: Station, StationType: StationType },
                    type: "post",
                    dataType: "text",
                    success: function (data) {
                        if (data == "true") {
                            layer.msg('修改成功');
                            $("#Search").click()
                        }
                    }
                });

            }
        });
    });
    $("input:seelect").click(function () {

        alert();
    })
})