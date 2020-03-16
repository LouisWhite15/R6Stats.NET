<template>
  <div class="playerSearch">
    <PlayerSearch msg="Player Search" />
  </div>
</template>

<script>
// @ is an alias to /src
import PlayerSearch from "@/components/PlayerSearch.vue";

export default {
  name: "playerSearch",
  components: {
    PlayerSearch
  }
};
</script>
