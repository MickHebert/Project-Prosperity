<script lang="ts">
    let username: String
    let password: String
    let userId: String | undefined
    let alertMsg: String | undefined
    let form: HTMLFormElement

    async function login() {
        alertMsg = ""
        const res = await fetch('http://localhost:5000/api/account/login', {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({username: username, password: password})
        })
        
        if (res.status == 200) {
            userId = await res.text()
        } else {
            alertMsg = "Login Failed"
            password = ""
        }
    }
</script>

<section class="main">
    {#if userId}
        <h1>Welcome {userId}</h1>
        <button on:click={() => userId = undefined}>Logout</button>
    {:else}
        {#if alertMsg}
            <p class="alertmsg">{alertMsg}</p>
        {/if}
        <div class="login">
            <form on:submit={login} method="dialog" bind:this={form}>
                <label>
                    Username
                    <input name="username" bind:value={username} type="text" required/>
                </label>
                <label>
                    Password
                    <input name="password" bind:value={password} type="password" required/>
                </label>
                <button>Log in</button>
            </form>
        </div>
    {/if}
</section>

<style>
    .alertmsg { color: #c12020; font-weight: bold; }
</style>
