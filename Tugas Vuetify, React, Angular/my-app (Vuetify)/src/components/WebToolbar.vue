<template>
    <v-toolbar app color="green darken-4" dark>
        <v-toolbar-side-icon></v-toolbar-side-icon>
        <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
        <div class="hidden-sm-and-down">
            <router-link class="link" to="/">
                <v-btn depressed color="green darken-4">Home</v-btn>
            </router-link>
            <v-btn depressed color="green darken-4">Profile</v-btn>
            <v-btn depressed color="green darken-4">Unit/Lembaga</v-btn>
            <v-btn depressed color="green darken-4">Akademi</v-btn>
            <v-btn depressed color="green darken-4">Dokumen</v-btn>
            <v-btn depressed color="green darken-4">Gallery</v-btn>
            <v-btn depressed color="green darken-4">Peta</v-btn>
            <v-btn depressed color="green darken-4">Video Profil</v-btn>
            <router-link class="link" to="/login">
                <v-btn depressed color="green darken-4">Kontak</v-btn>
            </router-link>
        </div>
        <div>
            <v-navigation-drawer v-model="drawer" absolute temporary expand-on-hover height="auto">
                <v-list-item class="pa-1">
                    <v-list-item-avatar>
                        <v-img src="https://scontent.fkno6-1.fna.fbcdn.net/v/t1.6435-9/193678547_765486964128565_6250452750723365419_n.jpg?stp=c0.135.526.526a_dst-jpg_p526x296&_nc_cat=101&ccb=1-7&_nc_sid=174925&_nc_eui2=AeHxqMDO6Yf-8d04OiasP2p4JaS_E-X4JyklpL8T5fgnKQeXxzWDlomppZ260FbWjdf3-axYzr2K7Z1MbaI7IiqN&_nc_ohc=YpaTkeLdThgAX8bNTPU&tn=1GDcnSY0avDrM2Sv&_nc_ht=scontent.fkno6-1.fna&oh=00_AfCB05kvcSBrl4KmlsTZoHGfWT1pQseA0GNPpsF-VeSupw&oe=639DA713" alt=""></v-img>
                    </v-list-item-avatar>
                    <v-list-item-content>
                        <v-list-item-title>Fikri Rivandi</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
                <v-list class="pt-0" dense>
                    <v-divider></v-divider>
                    <v-list-item v-for="item in items" :key="item.title" link @click="$router.push({path: item.link})">
                        <v-list-item-action>
                            <v-icon>{{item.icon}}</v-icon>
                        </v-list-item-action>

                        <v-list-item-content>
                            <v-list-tile-title>{{item.title}}</v-list-tile-title>
                        </v-list-item-content>
                    </v-list-item>
                </v-list>
            </v-navigation-drawer>
        </div>
    </v-toolbar>
</template>

<script>
export default {
    data() {
        return {
            drawer: null,
            items: [
                { title: 'Home', icon: 'dashboard', link:'/' },
                { title: 'Login', icon: 'login', link:'/login'}
            ]
        }
    }
}
</script>

<style>
.link {
    text-decoration: none;
}
</style>