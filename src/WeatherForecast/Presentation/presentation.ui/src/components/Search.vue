<template>
  <div id="search">
    <form v-on:submit.prevent="noop">
      <label for="search-box"></label>
      <input id="search-box"
             placeholder="Type here city name or yip code to get weather..."
             type="text"
             v-model="searchValue"
      v-on:keyup="onSearchBoxKeyUp"/>
    </form>
  </div>
</template>

<script>

export default {
  "name": "Search",
  "data"() {
    return {
      "searchValue": '',
    }
  },
  methods:{
    onSearchBoxKeyUp: function(e){
      if(e.keyCode === 13)
      {
        this.onSearch(this.searchValue);
      }
    },
    onSearch: function (q){
      this.$emit('my-event', q);
    }
  },
}
</script>

<style scoped>
#search-box {
  width: 100%;
}
</style>