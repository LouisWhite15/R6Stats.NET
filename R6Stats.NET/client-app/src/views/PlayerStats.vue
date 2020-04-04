<template>
  <div id="playerStats">
      <playerData :data="result"></playerData>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop, Provide } from "vue-property-decorator";
import PlayerData from "../components/PlayerData.vue";

@Component({
  components: {
    PlayerData
  }
})

export default class PlayerStats extends Vue {
  @Provide() result = [];
  @Prop() loading = false;

  async mounted() {
    this.loading = true;
    this.result = [];
    await Vue.axios
      .get(`https://localhost:5001/r6stats/player/${this.$route.path}`)
      .then((response) =>
      {
        this.loading=false;
        this.result = response.data;
      });
  }
}
</script>