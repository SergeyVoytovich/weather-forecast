<template>
  <form v-on:submit.prevent="noop">
    <div id="search">
      <div class="search-item">
        <label for="search-box"></label>
        <input id="search-box"
               placeholder="Type here name or zip code to search..."
               type="text"
               v-model="searchValue"
               v-on:keyup="onSearchBoxKeyUp"/>
      </div>
      <div class="search-item">
        <button v-on:click="search">Search</button>
      </div>
    </div>
  </form>
</template>

<script>

export default {
  "name": "Search",
  "data"() {
    return {
      "searchValue": '',
    }
  },
  methods: {
    onSearchBoxKeyUp: function (e) {
      if (e.keyCode === 13) {
        this.search();
      }
    },
    search: function () {
      this.$emit('my-event', this.searchValue);
    }
  },
}
</script>

<style scoped>

#search {
  display: grid;
  grid-template-columns: 100% 1fr;
  width: 100%;
}

#search-box {
  width: 100%;
}

.search-item {
  display: flex;
  margin-left: 10px;
}

</style>