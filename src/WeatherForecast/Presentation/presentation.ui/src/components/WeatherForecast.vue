<template>
  <div id="waether-app">
    <!--    {{ message }}-->
    <div id="content">
      <Search @myEvent="search"/>
      <div>
        <span v-bind:hidden="!nothingFound">No items found</span>
      </div>
      <List v-bind:items="items" v-bind:hidden="isItemsHidden" revers="true"/>
      <List  v-bind:items="defaultItems" v-bind:hidden="isMainHidden" revers="false"/>
    </div>
  </div>
</template>

<script>
import Search from "@/components/Search";
import List from "@/components/List";

export default {
  name: "WeatherForecast",
  components: {Search, List},
  data() {
    return {
      "nothingFound": false,
      "items": [],
      "defaultQueries": [
        "Stuttgart",
        "München",
        "Berlin",
        "Potsdam",
        "Bremen",
        "Frankfurt am Main",
        "Rostock",
        "Hannover",
        "Köln",
        "Mainz",
        "Saarbrücken",
        "Leipzig",
        "Halle",
        "Kiel",
        "Erfurt"
      ],
      "defaultItems": [],
    };
  },
  props: {
    message: String
  },
  methods: {
    search: function (q) {
      this.nothingFound = false;
      const self = this;
      fetch(this.getUri(q))
          .then(response => response.json())
          .then(data => {
            let removeIndex = -1;
            self.items.forEach(function (v, i) {
              if(data.name === v.name)
              {
                removeIndex = i;
              }
            })
            
            if(removeIndex > -1)
            {
              self.items.splice(removeIndex,1);
            }
            
            self.items.splice(0,0,data);
          })
          .catch(() => {
            self.nothingFound = true;
          });
    },
    getUri(q) {
      return 'http://localhost:8081/api/weather/forecast?q=' + q;
    },
    loadDefault: async function () {
      const self = this;
      for (const value of this.defaultQueries.sort()) {
        const response = await fetch(this.getUri(value));
        const json = await response.json();
        self.defaultItems.push(json);
      }
    }
  },
  beforeMount() {
    this.loadDefault();
  },
  computed:{
    isMainHidden:function (){
      return this.items.length > 0;
    },
    isItemsHidden:function (){
      return this.items.length === 0;
    }
  }
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
</style>