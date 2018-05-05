//index.js
//获取应用实例
const app = getApp()

Page({
  data: {
    motto: 'Hello 启点未来',
    pand:'none',
    inputTxt:"",
    videoPath:"",
   // canIUse: wx.canIUse('button.open-type.getUserInfo')
  },
  //事件处理函数
  bindViewTap: function() {
    wx.navigateTo({
      url: '../logs/logs'
    })
  },
  onLoad:function(){
    var that=this;
    wx.login({
      success:function(){
        wx.getUserInfo({
          success:function(res){
            that.setData({
              userImageSrc:res.userInfo.avatarUrl,
              userName:res.userInfo.nickName
            })
          }
        })
      }
    })
  },
  openPages:function(){
    wx.navigateTo({
      url: '../Registered/Registered'
    })

  },
  prompt:function(){
    wx:wx.showModal({
      title: '选择提示窗',
      content: '这是一个选择提示窗',
      success: function(res) {},
      fail: function(res) {},
      complete: function(res) {},
    })
  },
  playVideo:function(){
    var that=this
   wx.chooseVideo({
    sourceType:["album","camera"],
    maxDuration:60,
    camera:'back',
    success:function(res){
      that.setData({
         src:res.tempFilePath,
        videoPath:res.tempFilePath,
      })
      console.log(that.data.videoPath);
        wx: wx.navigateTo({
        url: '../ShowVideo/ShowVideo?src=' + that.data.videoPath,
      })

    }
  })
     
  },
  inputprompt:function()
  {
    this.setData({pand:'block'});
    console.log("123");
  },
cancel:function(){
this.setData({ pand:'none'})
},

confirm: function (e) {
  wx:wx.showToast({
    title: this.data.inputTxt,
  })
    this.setData({ pand: 'none' })
  },
inputtext:function(e){
  this.setData({
    inputTxt:e.detail.value,
  })
  
},
//查看我的位置
  checkPosition:function(){
  wx.getLocation({
    type:'wgs84',
    success: function(res) {
      //打开地图
      wx.openLocation({
        latitude: res.latitude,
        longitude: res.longitude,
      })
    },
    fail:function()
    {
      console.log('调用失败');
    }
  
  })
  },
  //连接测试
  connectTest:function(){
   wx.request({
     url: 'http://localhost:8080/home/wegeek',
     method:'Post',
     data:{
       x:'5',
       y:'20'
     },
     header:{
       'content-type':'application/json'
     },
     success:function(res){
       console.log(res.data);
       console.log(res.statusCode);
       console.log(res.header);

      wx.showToast({
        title:res.data.result,
      })
     }
   })
  }
  
})

