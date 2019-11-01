
export const components = () => {
    let client = () => import("@/pages/client");
    
    return {
        client: client
    }
}