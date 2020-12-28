<template>
  <div class="city-weather">
    <div class="city-name">
      <span>{{ city.name }}</span>
    </div>
    <div class="weather" >
      <div v-for="item in city.weather" v-bind:key="item">
        <div class="day" >
          <div class="day-name">
            {{ formatDay(item.date) }}
          </div>
          <div class="day-date">
            {{ formatDate(item.date) }}
          </div>
          <div class="info day-temp">
            <div><span class="icon icon-temperature" aria-hidden="true"></span></div>
            <div><span class="temp-value">{{ formatTemperature(item.temp) }}</span></div>
          </div>
          <div class="info day-unit">
            <div><span class="icon icon-unit icon-wind" aria-hidden="true"></span></div>
            <div><span>{{ item.speed }} m/s</span></div>
          </div>
          <div class="info day-unit">
            <div><span class="icon icon-unit icon-humidity" aria-hidden="true"></span></div>
            <div><span>{{ item.humidity }} %</span></div>
          </div>
          <div class="info day-unit">
            <div><span class="icon icon-unit icon-pressure" aria-hidden="true"></span></div>
            <div><span>{{ item.pressure }} hPa</span></div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

export default {
  name: "Item",
  props: {
    city: {}
  },
  methods : {
    formatDay: function(d){
      let date = new Date(d).setHours(0,0,0, 0);
      let today = new Date().setHours(0,0,0, 0);
      return date === today ? "Today" : new Date(d).toLocaleDateString("default", {
        weekday: "long"
      });
    },
    formatDate: function (d) {
      let date = new Date(d);
      return date.toLocaleDateString("default", {
        day: "2-digit",
        month: "short"
      });
    },
    formatTemperature: function (t){
      return (t > 0 ? "+" + t : t) + "°";
    },
  },
}

</script>

<style scoped>

.city-weather{
  margin-top: 20px;
  margin-bottom: 40px;
}

.weather {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
  width: 100%;
  text-align: left;
}
.city-name{
  text-align: left;
  font-size: 18px;
  font-weight: bold;
  margin-bottom: 4px;
}

.day{
  display: block;
}

.day-name{
  font-size: 14px;
}

.day-date{
  font-size: 10px;
  opacity: .6;
}

.info{
  display: grid;
  grid-template-columns: auto 1fr ;
}

.day-temp{
  font-size: 18px;
  font-weight: bold;
  margin: 6px;
}

.day-unit{
  font-size: 14px;
  opacity: .6;
}

.temp-value{
  min-height: 100%;
  display: inline-flex;
  align-items: center;
}

.icon {
  width: 24px;
  height: 24px;
  display: inline-block;
}

.icon-temperature{
  background-image: url("data:image/svg+xml;charset=utf-8,%3Csvg xmlns=%22http://www.w3.org/2000/svg%22 width=%2224%22 height=%2224%22 viewBox=%220 0 24 24%22%3E %3Cg fill=%22%23000%22 fill-rule=%22evenodd%22 id=%22%22%3E %3Cpath d=%22M9.25 12.602a4.5 4.5 0 1 0 4.5 0V5.75a2.25 2.25 0 1 0-4.5 0v6.852zm-1.5-.786V5.75a3.75 3.75 0 0 1 7.5 0v6.066a6 6 0 1 1-7.5 0z%22/%3E %3Ccircle cx=%2211.5%22 cy=%2216.5%22 r=%223%22/%3E %3Crect width=%221.5%22 height=%229%22 x=%2210.75%22 y=%228%22 rx=%22.75%22/%3E %3C/g%3E %3C/svg%3E");
}

.icon-unit{
  width: 16px;
  height: 16px;
  display: inline-block;
  opacity: .6;
  margin-right: 2px;
}

.icon-wind{
  background-image: url("data:image/svg+xml;charset=utf-8,%3Csvg xmlns=%22http://www.w3.org/2000/svg%22 width=%2216%22 height=%2216%22 viewBox=%220 0 24 24%22%3E %3Cg  fill-rule=%22nonzero%22%3E %3Cpath d=%22M6 11.5h5.688a3.75 3.75 0 1 0-1.95-6.954.75.75 0 0 0 .781 1.28A2.25 2.25 0 1 1 11.688 10L6 10.001a.75.75 0 1 0 0 1.5zM2 15h9.966a1.5 1.5 0 1 1-.779 2.782.75.75 0 0 0-.78 1.281 3 3 0 1 0 1.56-5.563H1.999A.75.75 0 1 0 2 15zM16.667 13h2.251a3 3 0 1 0-1.56-5.563.75.75 0 0 0 .781 1.28 1.5 1.5 0 1 1 .779 2.782l-2.251.001a.75.75 0 1 0 0 1.5z%22/%3E %3C/g%3E %3C/svg%3E");
}

.icon-humidity{
  background-image: url("data:image/svg+xml;charset=utf-8,%3Csvg xmlns=%22http://www.w3.org/2000/svg%22 width=%2216%22 height=%2216%22 viewBox=%220 0 24 24%22%3E %3Cg fill=%22%23000%22 fill-rule=%22nonzero%22%3E %3Cpath d=%22M21.365 18.657L10.74 15.81c-.708-.19-.424-1.253.285-1.063l10.625 2.847c.708.19.424 1.253-.285 1.063z%22/%3E %3Cpath d=%22M11.373 16.368a.55.55 0 0 0 .69.857l1.207-.97a.55.55 0 0 0 .168-.628l-.56-1.444a.55.55 0 0 0-1.026.398l.415 1.069-.894.718zM21.016 17.036a.55.55 0 0 0-.689-.857l-1.207.97a.55.55 0 0 0-.169.628l.561 1.444a.55.55 0 0 0 1.026-.398l-.415-1.069.893-.718zM17.087 22.157L14.24 11.532c-.19-.709.873-.993 1.063-.285l2.847 10.625c.19.709-.873.993-1.063.285z%22/%3E %3Cpath d=%22M14.074 12.36a.55.55 0 1 0-.398 1.025l1.444.56a.55.55 0 0 0 .628-.168l.97-1.208a.55.55 0 1 0-.857-.689l-.719.894-1.068-.415zM18.316 21.045a.55.55 0 0 0 .398-1.026l-1.444-.56a.55.55 0 0 0-.628.168l-.97 1.208a.55.55 0 0 0 .857.689l.718-.894 1.07.415zM20.473 13.202l-7.778 7.778c-.519.519-1.297-.26-.778-.778l7.778-7.778c.519-.519 1.296.26.778.778z%22/%3E %3Cpath d=%22M13.495 20.71a.55.55 0 1 0 1.087-.167l-.237-1.532a.55.55 0 0 0-.46-.46l-1.53-.236a.55.55 0 1 0-.169 1.087l1.134.175.175 1.133zM18.895 12.694a.55.55 0 0 0-1.087.168l.237 1.53a.55.55 0 0 0 .46.46l1.53.237a.55.55 0 0 0 .168-1.087l-1.133-.175-.175-1.133zM7 13.875c-2.38 0-4.292-2.052-4.292-4.563 0-.803.375-1.802 1.04-2.99.261-.466.564-.953.9-1.454A32.891 32.891 0 0 1 6.52 2.349L7 1.775l.48.574a32.891 32.891 0 0 1 1.873 2.519c.335.501.638.988.899 1.454.665 1.188 1.04 2.187 1.04 2.99 0 2.51-1.911 4.563-4.292 4.563zM6.922 3.851a31.661 31.661 0 0 0-1.236 1.713 20.47 20.47 0 0 0-.847 1.37c-.569 1.014-.88 1.846-.88 2.378 0 1.84 1.371 3.313 3.041 3.313s3.042-1.473 3.042-3.313c0-.532-.312-1.364-.88-2.379a20.47 20.47 0 0 0-.848-1.37A31.661 31.661 0 0 0 7 3.752l-.078.1z%22/%3E %3C/g%3E %3C/svg%3E");
}

.icon-pressure{
  background-image: url("data:image/svg+xml;charset=utf-8,%3Csvg xmlns=%22http://www.w3.org/2000/svg%22 width=%2216%22 height=%2216%22 viewBox=%220 0 24 24%22%3E %3Cg fill=%22%23000%22 fill-rule=%22nonzero%22%3E %3Cpath d=%22M13.524 9.415L15.47 7.47a.75.75 0 0 1 1.06 1.06l-1.945 1.946a3 3 0 1 1-1.06-1.06h-.001zM12 13.5a1.5 1.5 0 1 0 0-3 1.5 1.5 0 0 0 0 3z%22/%3E %3Cpath d=%22M12 22C6.477 22 2 17.523 2 12S6.477 2 12 2s10 4.477 10 10-4.477 10-10 10zm-.75-18.467A8.503 8.503 0 0 0 3.558 11H5v1.5H3.514a8.5 8.5 0 0 0 16.972 0H19V11h1.442a8.503 8.503 0 0 0-7.692-7.467V5h-1.5V3.533z%22/%3E %3C/g%3E %3C/svg%3E");
}
</style>