<template>
  <div id='waether-app'>
    <div id='content'>
      <Search @myEvent='search'/>
      <div>
        <span v-bind:hidden='nothingFoundHidden'>No items found</span>
      </div>
      <div class="tabs">
        <button v-bind:class="{active : !isHistoryHidden}" v-on:click="showTab('history')">history</button>
        <button v-bind:class="{active : !isMainHidden}" v-on:click="showTab('main')">main</button>
      </div>
      <List v-bind:items='history' v-bind:hidden='isHistoryHidden'/>
      <List v-bind:items='main' v-bind:hidden='isMainHidden'/>
    </div>
  </div>
</template>

<script>
import Search from '@/components/Search';
import List from '@/components/List';

const historyTab = 'history';
const mainTab = 'main';

export default {
  name: 'WeatherForecast',
  components: {Search, List},
  data() {
    return {
      'nothingFoundHidden': true,
      'history': [],
      'main': [],
      'isMainHidden': Boolean,
      'isHistoryHidden': Boolean,
      'mainCities': [
        'Stuttgart',
        'München',
        'Berlin',
        'Potsdam',
        'Bremen',
        'Frankfurt am Main',
        'Rostock',
        'Hannover',
        'Köln',
        'Mainz',
        'Saarbrücken',
        'Leipzig',
        'Halle',
        'Kiel',
        'Erfurt'
      ],
    };
  },
  props: {
    message: String
  },
  methods: {
    search: function (q) {
      this.nothingFoundHidden = true;
      const self = this;
      fetch(this.getUri(q))
          .then(response => response.json())
          .then(data => {
            let removeIndex = -1;
            self.history.forEach(function (v, i) {
              if (data.name === v.name) {
                removeIndex = i;
              }
            })

            if (removeIndex > -1) {
              self.history.splice(removeIndex, 1);
            }

            self.history.splice(0, 0, data);
            console.log(this.main[0]);
            self.showTab(historyTab);
          })
          .catch(() => {
            self.nothingFoundHidden = false;
          });
    },
    getUri(q) {
      return 'http://localhost:8081/api/weather/forecast?q=' + q;
    },
    loadMain: async function () {
      const self = this;
      for (const value of this.mainCities.sort()) {
        const response = await fetch(this.getUri(value));
        const json = await response.json();
        self.main.push(json);
      }      
    },
    showTab: function (tab) {
      this.isHistoryHidden = true;
      this.isMainHidden = true;
      switch (tab) {
        case  historyTab:
          console.log(historyTab);
          this.isHistoryHidden = false;
          break;
        case mainTab:
          console.log(mainTab);
          this.isMainHidden = false;
          break;
      }
    },
  },
  beforeMount() {
    this.loadMain();
    this.showTab(this.history.length > 0 ? historyTab : mainTab);
  },
  computed: {}
};
</script>

<style scoped>
#waether-app {
  width: 100%;
}

#content {
  max-width: 780px;
  min-width: 380px;
  margin: 0 auto;
}

.tabs{
  text-align: left;
  padding-top: 6px;
  padding-bottom: 12px;
}

.tabs button{
  background-color: #000000;
  float: left;
  border: none;
  outline: none;
  cursor: pointer;
  margin-right: 2px;
  transition: 0.3s;
  font-size: 11px;
  color: #fff;
  opacity: .25;
}

.tabs button:hover{
  opacity: .5;
}

.tabs button.active{
  opacity: 1;
}
</style>