function getRandomColor() {
  const rgb = []
  for (let i = 0; i < 3; ++i) {
    let color = Math.floor(Math.random() * 256).toString(16)
    color = color.length == 1 ? '0' + color : color
    rgb.push(color)
  }
  return '#' + rgb.join('')
}

//获取应用实例
const app = getApp()
Page({
   onReady:function(res){
     this.videoContext=wx.createVideoContext('myVideo')
   },
  /**
   * 页面的初始数据
   */
  inputValue:'',
  data: {
    srcVideo:'',
    src:'',
    danmuList:
    [
      {
        text:'第5秒出现的弹幕',
        color:'#ff0000',
        time:5
      },
      {
        text: '第11秒出现的弹幕',
        color: '#ff00ff',
        time: 11
      }
    ]
  },
  onLoad: function (options) {
    this.setData({
      srcVideo: options.src,
    })
  },
  bindInputBlur: function (e) {
    this.inputValue = e.detail.value
  },
  bindSendDanmu: function () {
    this.videoContext.sendDanmu({
      text: this.inputValue,
      color: getRandomColor()
    })
  },
  bindPlay: function () {
    this.videoContext.play()
  },
  bindPause: function () {
    this.videoContext.pause()
  },
  videoErrorCallback: function (e) {
    console.log('视频错误信息:')
    console.log(e.detail.errMsg)
  }
})