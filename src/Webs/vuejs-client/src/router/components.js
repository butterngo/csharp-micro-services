//export const account = () => import("@/components/HelloWorld");

export const components = () => {
    let account = () => import("@/components/HelloWorld");
    let accountOverview = () => import("@/components/HelloWorld2");

    return {
        accountOverview: accountOverview,
        account: account
        
    }
}