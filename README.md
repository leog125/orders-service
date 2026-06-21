# orders-service

Microservicio .NET para demostrar flujo GitOps con Docker, Helm, Kubernetes, ArgoCD y CI/CD.

## Endpoints

- `GET /health` -> valida que el servicio este disponible
- `GET /orders/{id}` -> devuelve una orden de ejemplo

## Ejecutar local

```bash
dotnet restore
dotnet run
```

Prueba:

```bash
curl http://localhost:5000/health
```

## Ejecutar pruebas

```bash
dotnet test
```

## Docker

```bash
docker build -t YOUR_USER/orders-service:1.0.0 .
docker run -p 8080:8080 YOUR_USER/orders-service:1.0.0
curl http://localhost:8080/health
```

## Kubernetes (manifiestos base)

```bash
kubectl apply -f k8s/deployment.yaml
kubectl get pods
kubectl port-forward svc/orders-service 8080:80
```

## CI/CD

El workflow en `.github/workflows/ci-cd.yml`:

1. Restaura y ejecuta pruebas.
2. Construye y publica imagen Docker con tag SHA.
3. Actualiza `values-prod.yaml` en el repo de despliegue.
4. ArgoCD detecta el commit y sincroniza el cluster.

Secrets requeridos:

- `REGISTRY_USER`
- `REGISTRY_PASSWORD`
- `DEPLOY_REPO` (formato `owner/repo`)
- `DEPLOY_REPO_TOKEN` (PAT con permiso de push al repo de despliegue)
